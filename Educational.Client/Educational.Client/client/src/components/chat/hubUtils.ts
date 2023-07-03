import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import { HubConnection } from '@microsoft/signalr/dist/esm/HubConnection';

export function buildConnection(token: string): HubConnection {
    const connection = new HubConnectionBuilder()
        .withUrl("https://localhost:44323/chat", {
            accessTokenFactory: () => String(token)
        })
        .withAutomaticReconnect()
        .configureLogging(LogLevel.Information)
        .build();

    return connection;
}
export async function startConnection(connection: HubConnection): Promise<void> {
    try {
        await connection.start();
        console.log('Connected!');
    } catch (e) {
        console.log('Connection failed: ', e)
    }
}