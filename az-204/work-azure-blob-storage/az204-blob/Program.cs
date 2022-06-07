using az204_blob.StorageClass;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Azure Blob storage Lab\n");

// Run the examples asynchronously, wait for the results before proceeding
StorageClass.ProcessAsync().GetAwaiter().GetResult();

Console.WriteLine("Press enter to exit the sample application.");
Console.ReadLine();







