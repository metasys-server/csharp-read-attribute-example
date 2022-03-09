// The built-in .Net HttpClient could be used
// But flurl has a nicer API and deserializes the JSON for us
using Flurl.Http;

var host = "{provide host}";
var username = "{provide username}";

// For test systems only. Never embed plain text passwords in your code.
var password = "{provide password}";

// Object IDs are available within MUI or using GET /objectIdentifiers?fqr={fqr}
var object1Id = "960534d2-7df5-5ed8-884c-164e7a2f280a";
var object2Id = "c82d160b-884c-5eac-bad4-89754f0069e0";

// Login and get a token
string accessToken;

using (var client = new FlurlClient($"https://{host}/api/v3"))
{
    var loginObject = new
    {
        Username = username,
        Password = password
    };

    // This line invokes the operation: POST /api/v3/login
    accessToken = (await client.Request($"https://{host}/api/v3/login").PostJsonAsync(loginObject)
        .ReceiveJson()).accessToken;
}

// Use the token to read two attributes

// Creates an http client with base url of our API and using the access token
using (var client = new FlurlClient($"https://{host}/api/v3").WithOAuthBearerToken(accessToken))
{
    // The next two lines actually read the present value of 2 objects.
    // They are invoking the operation: GET /objects/{id}/attributes/presentValue
    var attribute1Response = await client.Request($"https://{host}/api/v3/objects/{object1Id}/attributes/presentValue").GetJsonAsync();
    var attribute2Response = await client.Request($"https://{host}/api/v3/objects/{object2Id}/attributes/presentValue").GetJsonAsync();

    // The next two lines take advantage of the fact that attribute1Response
    // and attribute2Response are dynamic objects that allow us to query the
    // responses with properties.
    Console.WriteLine($"Value 1: {attribute1Response.item.presentValue}");
    Console.WriteLine($"Value 2: {attribute2Response.item.presentValue}");
}
