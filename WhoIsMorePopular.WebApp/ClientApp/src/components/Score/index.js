import React from "react"
import { Container} from './styles'

export const Score = ({ data, type }) => {

    const Provider = () => data.map((x, i) => <Container key={i}>In <span>{x.provider}</span> the winner is <span>{x.winner}</span>.</Container>)
    const Detail = () => data.map((x, i) => <Container key={i}><span>{x.word}</span> has obtained <span>{x.total}</span> search results in {x.provider}.</Container>)

    return (
        type === "Provider" ? <Provider /> : <Detail />
    )
}