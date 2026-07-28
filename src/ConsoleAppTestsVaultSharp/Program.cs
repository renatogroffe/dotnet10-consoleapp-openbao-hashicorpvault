using VaultSharp;
using VaultSharp.V1.AuthMethods;
using VaultSharp.V1.AuthMethods.Token;
using VaultSharp.V1.Commons;

Console.WriteLine("*** Testes com .NET 10 + HashiCorp Vault/OpenBao + VaultSharp (pacote NuGet) ***");

IAuthMethodInfo authMethod = new TokenAuthMethodInfo("1f91d80e-0a03-49b3-b84b-f1de3d172eec");

var vaultClientSettings = new VaultClientSettings("http://localhost:1337", authMethod);
IVaultClient vaultClient = new VaultClient(vaultClientSettings);

Console.WriteLine("");
Console.WriteLine("Lendo primeiro secret do Vault - app/config...");
Secret<SecretData> kv2Secret1 =
    await vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync(
        path: "app/config",
        mountPoint: "secret");

string? username = kv2Secret1.Data.Data["username"].ToString();
string? password = kv2Secret1.Data.Data["password"].ToString();

Console.WriteLine($"username = {username}");
Console.WriteLine($"password = {password}");


Console.WriteLine("");
Console.WriteLine("Lendo primeiro secret do Vault - app/config...");
Secret<SecretData> kv2Secret2 =
    await vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync(
        path: "integracoes/api",
        mountPoint: "secret");

string? api_key = kv2Secret2.Data.Data["api_key"].ToString();
string? endpoint = kv2Secret2.Data.Data["endpoint"].ToString();

Console.WriteLine($"api_key = {api_key}");
Console.WriteLine($"endpoint = {endpoint}");

Console.WriteLine();
Console.WriteLine("Pressione qualquer tecla para sair...");
Console.ReadLine();