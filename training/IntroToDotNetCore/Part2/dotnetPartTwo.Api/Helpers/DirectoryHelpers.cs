using System;
using System.IO;
using System.Linq;

namespace dotnetPartTwo.Api.Helpers
{
    public static class DirectoryHelpers
    {
        public static string GetApplicationRoot()
        {
            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var pathSections = path.Split("/", StringSplitOptions.RemoveEmptyEntries).ToList();
            var returnPath = "/";
            foreach (var section in pathSections)
            {
                if (section != "bin")
                    {
                        returnPath += section;
                        returnPath += "/";
                    }
                else break;
            }

            return returnPath;
        }         
    }
}