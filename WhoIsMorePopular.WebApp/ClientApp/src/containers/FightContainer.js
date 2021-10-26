import React, { useState } from "react"
import { Searcher } from '../components/Searcher'
import { Score } from '../components/Score'

export const FightContainer = () => {

    const [scores, setScores] = useState([])

    const handleOnSubmit = async (values) => {
        setScores([])
        console.log('values =>', values)

        var query = encodeURIComponent(values);
        const response = await fetch(`Search/${query}`);
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