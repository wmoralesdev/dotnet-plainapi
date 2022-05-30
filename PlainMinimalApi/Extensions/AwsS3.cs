using Amazon.S3;

namespace PlainMinimalApi.Extensions;

public class AwsS3
{
    private readonly AmazonS3Client _s3Client;
    
    public AwsS3(IConfiguration config)
    {
        
    }
}