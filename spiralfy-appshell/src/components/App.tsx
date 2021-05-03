import { ExtensionSlot, LayoutProps } from 'piral-core';
import { Menu } from 'piral-menu';
import * as React from 'react';
import Footer from './Footer';
import Logo from './Logo';

const App: React.FC<LayoutProps> = ({ children }) => (
  <>
    <header className="Header">
      <Logo />
      <Menu type="general" />
      <ExtensionSlot name="header-items" />
    </header>
    <main className="Main">{children}</main>
    <Footer />
  </>
);

export default App;
