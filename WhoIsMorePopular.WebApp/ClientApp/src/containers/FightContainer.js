import React, { useState } from "react"
import { Searcher } from '../components/Searcher'
import { Winner } from '../components/Winner'
import { Score } from '../components/Score'


const initialState = {
    providerDetail: [],
    resultDetail: [],
    winner: null
}

export const FightContainer = () => {

    const [values, setValues] = useState(initialState)

    const handleOnSubmit = async (values) => {
        var query = encodeURIComponent(values);
        const response = await fetch(`Search/${query}`);
        const data = await response.json();
        setValues(data)
        console.log('response =>', data)
    }

    return (
        <>
            <Searcher onSubmit={handleOnSubmit} />
            {values.winner && <Winner data={values.winner} />}
            {values.providerDetail &&  <Score data={values.providerDetail} type="Provider" />}
            {values.resultDetail && <Score data={values.resultDetail} type="Detail" />}
        </>
    )
}