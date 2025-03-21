namespace FileSystemLibrary
{
    public static class FileSystemOperations
    {
        public static void CopyFile(string sourceFilePath, string destFilePath, bool overwrite = false)
        {
            if (File.Exists(sourceFilePath))
                File.Copy(sourceFilePath, destFilePath, overwrite);
            else
                throw new FileNotFoundException($"Источник файла не найден: {sourceFilePath}");
        }

        public static void CopyDirectory(string sourceDirPath, string destDirPath, bool overwrite = false)
        {
            if (Directory.Exists(sourceDirPath))
            {
                Directory.CreateDirectory(destDirPath);

                foreach (var file in Directory.GetFiles(sourceDirPath))
                {
                    var destFile = Path.Combine(destDirPath, Path.GetFileName(file));
                    File.Copy(file, destFile, overwrite);
                }

                foreach (var directory in Directory.GetDirectories(sourceDirPath))
                {
                    var destDirectory = Path.Combine(destDirPath, Path.GetFileName(directory));
                    CopyDirectory(directory, destDirectory, overwrite);
                }
            }
            else
                throw new DirectoryNotFoundException($"Источник директории не найден: {sourceDirPath}");
        }

        public static void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
            else
                throw new FileNotFoundException($"Файл не найден: {filePath}");
        }

        public static void DeleteFilesByNames(string[] fileNames, string directoryPath)
        {
            foreach (var fileName in fileNames)
            {
                var filePath = Path.Combine(directoryPath, fileName);
                DeleteFile(filePath);
            }
        }

        public static void DeleteFilesByMask(string directoryPath, string mask)
        {
            var files = Directory.GetFiles(directoryPath, mask);
            foreach (var file in files)
                DeleteFile(file);
        }

        public static void MoveFile(string sourceFilePath, string destFilePath)
        {
            if (File.Exists(sourceFilePath))
                File.Move(sourceFilePath, destFilePath);
            else
                throw new FileNotFoundException($"Источник файла не найден: {sourceFilePath}");
        }
    }
}
