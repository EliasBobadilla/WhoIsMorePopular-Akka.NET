import styled from 'styled-components'

export const Container = styled.div`
  display: flex;
  flex-direction: column;
  align-content: center;
  align-items: center;
  gap: 15px;
  
  > textarea {
    color: #1d3861;
    font-size: 1em;
    font-weight: lighter;
    letter-spacing: 1px;
    padding: 10px;

    &::placeholder {
      color: #adadad;
    }
  }
`

export const Button = styled.input.attrs({ 
  type: 'button',
  value: 'Fight'
})`
  font-family: 'Poppins', sans-serif;
  background-color: #1d3861;
  width: 100%;
  height: 50px;
  text-transform: uppercase;
  letter-spacing: 2px;
  font-size: 1.5em;
  color: white;
  border: none;
`