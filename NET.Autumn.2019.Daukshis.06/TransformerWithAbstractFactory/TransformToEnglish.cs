﻿namespace TransformerWithAbstractFactory
{
    public class TransformToEnglish : TransformerFactory
    {
        public override TransformationMethod ToStringMethod()
        {
            return new EnglishDictionary();
        }
    }
}