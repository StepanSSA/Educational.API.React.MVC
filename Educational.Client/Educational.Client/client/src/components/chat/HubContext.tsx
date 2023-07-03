import { HubConnection } from "@microsoft/signalr";
import { createContext, ReactNode, useState, useEffect } from "react";
import { buildConnection, startConnection } from './hubUtils';
import { Message } from "./message";

interface IHubContext {
    connection?: HubConnection
    connectionStarted: boolean

    messages?: Message[]
    startNewConnection(token: string): any
}

export const HubContext = createContext<IHubContext | null>(null)

export const HubContextProvider = ({ children }: { children: ReactNode }) => {

    const [connection, setConnection] = useState<HubConnection>();
    const [connectionStarted, setConnectionStarted] = useState(false);
    const [messages, setMessages] = useState<Message[]>([]);

    

    const startNewConnection = (token: string) => {
        const newConnection = buildConnection(String(token));
        console.log("connection == ", newConnection)
        setConnection(newConnection);
    }

    useEffect(() => {
        if (connection) {
            console.log("startConnection")
                startConnection(connection)
                    .then(() => {
                        setConnectionStarted(true)
                        connection.on("SendMessageRecipientAsync", (senderId, message, recipientId) => {
                            console.log("message", message);
                        });
                        connection.on("SendMessageAsync", (username, message) => {
                            console.log("username == ", username, message)
                            setMessages(mes => [...messages, { username, message }]);
                        });
                        connection.onclose(() => {
                            const token = localStorage.getItem('token');
                            startNewConnection(String(token));
                        });
                    });
        }
    }, [connection]);

    return (
        <HubContext.Provider value={{ connection, connectionStarted, messages, startNewConnection}}>
            {children}
        </HubContext.Provider>
    );
}