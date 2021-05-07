import * as React from 'react';
import { Link, useLocation } from 'react-router-dom';

const Logo: React.FC = () => {
  const loc = useLocation();
  const logoLocationDescriptor = { ...loc, pathname: '/' }; //keep the url query strings etc

  return (
    <div className="Logo">
      <img src="https://i.imgur.com/np3G6lO.png" style={{ height: '2rem' }} />
      <Link to={logoLocationDescriptor}>Spiralfy</Link>
    </div>
  );
};

export default Logo;
