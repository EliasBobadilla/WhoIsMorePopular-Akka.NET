import React from 'react';
import {GlobalStyle} from './styles/GlobalStyle'
import { Layout } from './components/Layout';
import { FightContainer } from './containers/FightContainer'

const App = () => <>
  <GlobalStyle />
  <Layout>
    <FightContainer />
  </Layout>
</>


export default App