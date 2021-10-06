import { AzureFunction, Context, HttpRequest } from "@azure/functions"
import { verifyKey } from "discord-interactions";

const httpTrigger: AzureFunction = async function (context: Context, req: HttpRequest): Promise<void> {
    let publicKey: string | undefined = req.headers["publickey"];
    let signature: string | undefined = req.headers["signature"];
    let timestamp: string | undefined = req.headers["timestamp"];
    let body: string | undefined = req.rawBody;

    if (timestamp && body && signature && publicKey) {
        let isVerified: boolean = verifyKey(body, signature, timestamp, publicKey)

        if (isVerified) {
            context.res = {
                body: true
            }
        }
        else {
            context.res = {
                status: 401,
                body: "Invalid request signature."
            }
        }
    } else {
        context.res = {
            status: 401,
            body: "Not public key, signature, timestamp or body was provided."
        }
    }

};

export default httpTrigger;