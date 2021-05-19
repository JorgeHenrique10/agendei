using System;
using System.IO;

namespace Agendei.Dominio.Services
{
    public class Service
    {
        public string SaveFile(string base64)
        {
            //string base64 = "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";
            //base64 = base64.Replace("data:image/pdf;base64,", "");
            var NomeArquivo = Guid.NewGuid().ToString() + DateTime.Now.ToString();
            NomeArquivo = NomeArquivo.Replace("/", "").Replace("-", "").Replace(" ", "").Replace(":", "");
            File.WriteAllBytes($@"C:\dev\Agendei\Agendei.Dominio\images\{NomeArquivo}.jpg", Convert.FromBase64String(base64));

            return NomeArquivo;
        }
    }
}