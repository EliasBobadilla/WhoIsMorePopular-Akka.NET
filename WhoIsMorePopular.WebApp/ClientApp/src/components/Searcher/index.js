import React, { useState } from "react"
import { Container, Button } from './styles'

export const Searcher = ({ onSubmit }) => {

    const [values, setValues] = useState('')
    const [valid, setValid] = useState(false)

    const handleOnchange = (text) => {
        setValues(text)
        isValid(text)
    }

    const isValid = (text) => {
        if (!text) {
            setValid(false)
            return
        }

        const list = text.split(',')
        setValid(list.length > 1 && list.every(word => word && word.trim().length > 0))
    }

    return (
        <Container>
            <textarea
                rows="4"
                cols="50"
                onChange={(e) => handleOnchange(e.target.value)}
                placeholder="Write your values separated by commas and then click on the Fight button"
            />
            <Button onClick={() => onSubmit(values)} disabled={!valid} />
        </Container>
    )
}