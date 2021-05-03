import * as React from 'react';
import { Link } from 'react-router-dom';

const Logo: React.FC = () => (
  <div className="Logo" style={{ fontWeight: 'bold', fontSize: '2rem' }}>
    <Link to="/">Spiralfy</Link>
  </div>
);

export default Logo;
