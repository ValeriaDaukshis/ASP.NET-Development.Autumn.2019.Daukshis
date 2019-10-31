using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

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
			Excel.Application ex = new Excel.Application();
			ex.Workbooks.Open(xlsxFileName,
				Type.Missing, Type.Missing, Type.Missing, Type.Missing,
				Type.Missing, Type.Missing, Type.Missing, Type.Missing,
				Type.Missing, Type.Missing, Type.Missing, Type.Missing,
				Type.Missing, Type.Missing);
			Excel.Worksheet sheet = (Excel.Worksheet)ex.Worksheets.get_Item(1);
			int min_i = 1, min_j = 1;
			while (string.IsNullOrEmpty(sheet.Cells[min_i, 1].ToString()))
			{
				min_i++;
			}

			while (string.IsNullOrEmpty(sheet.Cells[1, min_j].ToString()))
			{
				min_j++;
			}
			
			var max_i = min_i;
			var max_j = min_j;
			
			while (!string.IsNullOrEmpty(sheet.Cells[max_i, 1].ToString()))
			{
				max_i++;
			}

			while (!string.IsNullOrEmpty(sheet.Cells[1, max_j].ToString()))
			{
				max_j++;
			}

			for (int i = min_i; i <= max_i; i++)
			{
				for (int j = min_j; j <= max_j; j++)
				{
					if(sheet.Cells[i, j].ToString() == null)
						break;
				
				}
			}
			
			// TODO : Implement ReadPlanetInfoFromXlsx method using System.IO.Packaging + Linq-2-Xml

			// HINT : Please be as simple & clear as possible.
			//        No complex and common use cases, just this specified file.
			//        Required data are stored in Planets.xlsx archive in 2 files:
			//         /xl/sharedStrings.xml      - dictionary of all string values
			//         /xl/worksheets/sheet1.xml  - main worksheet

			throw new NotImplementedException();
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
	}
}