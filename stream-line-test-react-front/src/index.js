import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import { MyContext } from './components/common/Context';
import { BrowserRouter } from 'react-router-dom';

ReactDOM.render(
  <>
    <BrowserRouter>
      <MyContext>
        <App />
      </MyContext>
    </BrowserRouter>
  </>,
  document.getElementById('root')
);
