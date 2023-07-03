import React from 'react';
import ReactDOM from 'react-dom/client';
import './style/style.css';
import './components/header.css'
import 'bootstrap/dist/css/bootstrap.min.css'
import App from './app';
import { HubContextProvider } from './components/chat/HubContext';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <React.StrictMode>
    <HubContextProvider>
      <App/>
    </HubContextProvider>
  </React.StrictMode>
);

