using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using OfficeOpenXml;

namespace Streams
{
	public static class StreamTask
	{
		/// <summary>
		/// Parses Resources\Planets.xlsx file and returns the planet data: 
		///   Jupiter     69911.00
		///   Saturn      58232.00
		///   Uranus      25362.00
		///    ...
		/// See Resources\Planets.xlsx for details
		/// </summary>
		/// <param name="xlsxFileName">Source file name.</param>
		/// <returns>Sequence of PlanetInfo</returns>
		public static IEnumerable<PlanetInfo> ReadPlanetInfoFromXlsx(string xlsxFileName)
		{
			List<string> excelData = new List<string>();
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(xlsxFileName)))
			{
				var worksheet = excelPackage.Workbook.Worksheets.First();
				int count = GetPropCount();
               
				for (int i = worksheet.Dimension.Start.Row; i <= worksheet.Dimension.End.Row; i++)
				{
					for (int j = worksheet.Dimension.Start.Column; j <= worksheet.Dimension.End.Column; j++)
					{
						if (worksheet.Cells[i, j].Value != null)
						{
							excelData.Add(worksheet.Cells[i, j].Value.ToString()); 
						}
					}

					PlanetInfo info = WriteToPlanetInfo(excelData, count);
					if (info != null)
						yield return info;
					excelData.Clear();
				}
			}
		}

		/// <summary>
		/// Calculates hash of stream using specified algorithm.
		/// </summary>
		/// <param name="stream">Source stream</param>
		/// <param name="hashAlgorithmName">
		///     Hash algorithm ("MD5","SHA1","SHA256" and other supported by .NET).
		/// </param>
		/// <returns></returns>
		public static string CalculateHash(this Stream stream, string hashAlgorithmName)
		{
			var hashAlgorithm = HashAlgorithm.Create(hashAlgorithmName);
			
			if (hashAlgorithm is null)
			{
				throw new ArgumentException();
			}
			
			if (stream is null)
			{
				throw new ArgumentException();
			}

			byte[] hash;

			hash = hashAlgorithm.ComputeHash(stream);

			StringBuilder sBuilder = new StringBuilder();
			
			for (int i = 0; i < hash.Length; i++)
			{
				sBuilder.Append(hash[i].ToString("x2").ToUpper());
			}
			
			return sBuilder.ToString();
		}

		/// <summary>
		/// Returns decompressed stream from file. 
		/// </summary>
		/// <param name="fileName">Source file.</param>
		/// <param name="method">Method used for compression (none, deflate, gzip).</param>
		/// <returns>output stream</returns>
		public static Stream DecompressStream(string fileName, DecompressionMethods method)
		{
			if (method is DecompressionMethods.None)
			{
				return File.OpenRead(fileName);
			}

			if (method is DecompressionMethods.Deflate)
			{
				return new DeflateStream(File.OpenRead(fileName), CompressionMode.Decompress);
			}
			
			if (method is DecompressionMethods.GZip)
			{
				return new GZipStream(File.OpenRead(fileName), CompressionMode.Decompress);
			}

			return File.OpenRead(fileName);
		}

		/// <summary>
		/// Reads file content encoded with non Unicode encoding
		/// </summary>
		/// <param name="fileName">Source file name</param>
		/// <param name="encoding">Encoding name</param>
		/// <returns>Unicoded file content</returns>
		public static string ReadEncodedText(string fileName, string encoding)
		{
			if (string.IsNullOrEmpty(encoding))
			{
				throw new ArgumentException();
			}
			string initText;
			Encoding encoding2 = Encoding.GetEncoding(encoding);
			using (StreamReader reader = new StreamReader(new FileStream(fileName, FileMode.OpenOrCreate), encoding2))
			{
				initText = reader.ReadToEnd();
			}

			var unicode = new UnicodeEncoding();

			byte[] byteText = unicode.GetBytes(initText);
			string encodedText = unicode.GetString(byteText);
			return encodedText;
		}
		
		private static PlanetInfo WriteToPlanetInfo(List<string> excelData, int count)
		{
			if (excelData.Count != count)
				return null;

			if (!Double.TryParse(excelData[1], out var a))
				return null;

			return new PlanetInfo { Name = excelData[0], MeanRadius = Double.Parse(excelData[1]) };
		}

		private static int GetPropCount()
		{
			return typeof(PlanetInfo).GetProperties().Length;
		}
	}
}