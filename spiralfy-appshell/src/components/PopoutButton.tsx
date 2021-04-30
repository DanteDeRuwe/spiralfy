import * as React from 'react';

const popout = () =>
  window.open(
    document.location.href,
    'Spiralfy',
    `scrollbars=no,resizable=no,status=no,location=no,toolbar=no,menubar=no,width=500,height=1000`
  );

const PopoutButton: React.FC = () => (
  <button onClick={popout} className="Button" style={{ padding: '1rem', marginLeft: 0 }}>
    <img src="https://api.iconify.design/akar-icons:link-out.svg?color=%23fff" />
  </button>
);

export default PopoutButton;
