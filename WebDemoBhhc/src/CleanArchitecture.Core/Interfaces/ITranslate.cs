using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Interfaces
{
    public interface ITranslate
    {
        string GetTranslation(string input, int languageType);
    }
}
