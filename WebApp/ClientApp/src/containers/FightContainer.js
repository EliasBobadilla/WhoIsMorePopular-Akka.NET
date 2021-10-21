import React, { useState, useEffect } from "react"
import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";
import { Searcher } from '../components/Searcher'
import { Score } from '../components/Score'

export const FightContainer = () => {

    const [connection, setConnection] = useState(null);
    const [scores, setScores] = useState([])

    useEffect(() => {
        const connect = new HubConnectionBuilder()
            .withUrl("https://localhost:5001/hubs/notification")
            .withAutomaticReconnect()
            .build();

        setConnection(connect);
    }, []);

    useEffect(() => {
        if (connection) {
            connection
                .start()
                .then(() => {
                    connection.on("ReceiveMessage", (message) => {
                        console.log('desde signalr', message)
                    });
                })
                .catch((error) => console.log(error));
        }
    }, [connection]);

    const handleOnSubmit = async (values) => {
        setScores([])
        console.log('values =>', values)

        var query = encodeURIComponent(values);
        const response = await fetch(`Fight/${query}`);
        const data = await response.json();
        console.log('response =>', data)
    }

    return (
        <>
            <Searcher onSubmit={handleOnSubmit} />
            {scores.map(score => <Score score={score} />)}
        </>
    )
}