using Kafuu.Core.Models.Discord.Interactions.ReceivingAndResponding;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kafuu.Api.Controllers.Interactions;

[ApiController]
[Route("Interactions/[controller]")]
public class ReceivingAndRespondingController : ControllerBase
{
	[HttpGet]
	public void Get() => this.Ok();

	[HttpPost]
	[Authorize(AuthenticationSchemes = "DiscordSignature")]
	[Consumes("application/json")]
	[Produces("application/json")]
	public ActionResult<InteractionResponse> Post([FromBody] Interaction interaction)
	{
		switch (interaction.Type)
		{
			case InteractionType.Ping:
				return new InteractionResponse(InteractionCallbackType.Pong);

			case InteractionType.ApplicationCommand:
			{
				switch (interaction.Data.Value)
				{
					case ApplicationCommandInteractionData:
					{
						Core.Models.Kafuu.ApplicationCommand? applicationCommand = Core.Interactions.ApplicationCommands.GlobalApplicationCommands.Find(
							applicationCommand => applicationCommand.Name.ToLower() == ((ApplicationCommandInteractionData)interaction.Data).Name);

						return applicationCommand != null
							? new InteractionResponse(
								InteractionCallbackType.ChannelMessageWithSource,
								applicationCommand.InteractionCallback())
							: this.NotFound();
					}
				}

				return this.NotFound();
			}
		}

		return this.NotFound();
	}
}
