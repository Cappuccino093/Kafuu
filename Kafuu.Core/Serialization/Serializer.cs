using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Kafuu.Core.Serialization;

public static class Serializer
{
	public static T Deserialize<T>(string json) => JsonSerializer.Deserialize<T>(json, Kafuu.JsonSerializerOptions);
	public static string Serialize<T>(T t) => JsonSerializer.Serialize<T>(t, Kafuu.JsonSerializerOptions);
}
