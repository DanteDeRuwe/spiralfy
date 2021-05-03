import { ExtensionSlot, LayoutProps } from 'piral-core';
import { Menu } from 'piral-menu';
import * as React from 'react';
import Logo from './Logo';
import Footer from './Footer';
import { Route } from 'react-router-dom';
import PopoutButton from './PopoutButton';

const App: React.FC<LayoutProps> = ({ children }) => (
  <>
    <div className="main-wrapper">
      <header className="Header">
        <Logo />
        <Menu type="general" />
        <ExtensionSlot name="header-items" />
      </header>
      <Route exact path="/">
        <ExtensionSlot name="homepage" />
      </Route>
      {children}
    </div>
    <Footer />
  </>
);

export default App;
