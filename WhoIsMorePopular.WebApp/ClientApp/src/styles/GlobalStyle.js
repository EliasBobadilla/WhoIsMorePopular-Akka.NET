import { createGlobalStyle } from 'styled-components'

// min width 1080px

export const GlobalStyle = createGlobalStyle`
  * {
    box-sizing: border-box;
  }

  p {
    margin: 0;
  }

  body {
    font-family: 'Poppins', sans-serif;
    color: #707070;
    font-size: 14px;
    height: 100%;
    margin: 0;
    padding: 0;
    overscroll-behavior: none;
    width: 100%;
    background-color: #1d3861;
  }
  html {
    box-sizing: border-box;
  }

  *,
  *:before,
  *:after {
    box-sizing: inherit;
  }

  ul,
  li,
  h1,
  h2,
  h3,
  p,
  button {
    margin: 0;
    padding: 0;
  }

  ul {
    list-style: none;
  }

`