import React from 'react';
import {Header} from '../Header'
import {Container} from './styles'

export const Layout = ({children}) => {
    return (
      <Container>
        <Header />
          {children}
      </Container>
    );
}
