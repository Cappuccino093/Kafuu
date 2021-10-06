using System;
using System.Text.RegularExpressions;
using Kafuu.Core.Models.Discord;
using Kafuu.Core.Models.Discord.Interactions.ApplicationCommands;
using Kafuu.Core.Models.Discord.Resources.Channel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kafuu.MSTest;
[TestClass]
public class JsonSerialize
{
	[TestMethod]
	public void Write()
	{
		ApplicationCommand applicationCommand = new(new(), new(), "a", "a", new());
		string json = Core.Serialization.Serializer.Serialize(applicationCommand);
		Console.WriteLine(json);
	}

	[TestMethod]
	public void Read()
	{
		string json =
@"{
	""id"": ""0"",
	""application_id"":""0"",
	""name"":""a"",
	""description"":""a"",
	""version"":""0""
}";
		ApplicationCommand applicationCommand = Core.Serialization.Serializer.Deserialize<ApplicationCommand>(json);
		Console.WriteLine(applicationCommand);
	}

	[TestMethod]
	public void WriteEnumCustomName()
	{
		AllowedMentions allowedMentions = new(
			new AllowedMentionType[] { AllowedMentionType.RolesMentions, AllowedMentionType.UsersMentions, AllowedMentionType.EveryoneMentions },
			Array.Empty<Snowflake>(),
			Array.Empty<Snowflake>(),
			false);
		string json = Core.Serialization.Serializer.Serialize(allowedMentions);
		Console.WriteLine(json);
	}

	[TestMethod]
	public void ReadEnumCustomName()
	{
		string json = @"{""parse"":[""roles"",""users"",""everyone""],""roles"":[],""users"":[],""replied_user"":false}";
		AllowedMentions test = Core.Serialization.Serializer.Deserialize<AllowedMentions>(json);
		Console.WriteLine(test);
	}
}