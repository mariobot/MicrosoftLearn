using System.ComponentModel.DataAnnotations;

namespace HydroProject.Pages.Components;

public class AddAttachment : HydroComponent
{
    [Transient]
    public IFormFile DocumentFile { get; set; }

    [Required]
    public string DocumentId { get; set; }

    public async Task Save()
    {
        if (!Validate())
        {
            return;
        }

        var tempFilePath = GetTempFileLocation(DocumentId);

        // Move your file at tempFilePath to the final storage
        // and save that information in your domain
    }

    public override async Task BindAsync(PropertyPath property, object value)
    {
        if (property.Name == nameof(DocumentFile))
        {
            // assign the temp file name to the DocumentId
            DocumentId = await GetStoredTempFileId((IFormFile)value);
        }
    }

    private static async Task<string> GetStoredTempFileId(IFormFile file)
    {
        if (file == null)
        {
            return null;
        }

        var tempFileName = Guid.NewGuid().ToString("N");
        var tempFilePath = GetTempFileLocation(tempFileName);

        await using var readStream = file.OpenReadStream();
        await using var writeStream = File.OpenWrite(tempFilePath);
        await readStream.CopyToAsync(writeStream);

        return tempFileName;
    }

    private static string GetTempFileLocation(string fileName) =>
        Path.Combine(Path.GetTempPath(), fileName);

}
