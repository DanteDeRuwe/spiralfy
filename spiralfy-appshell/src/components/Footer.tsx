import * as React from 'react';
import PopoutButton from './PopoutButton';

const Footer: React.FC = () => (
  <>
    <footer>
      <p className="text-lightgray">Made with</p>
      <p>
        <a target="_blank" href="https://reactjs.org">
          <img id="react-logo" src="https://i.imgur.com/gNxwwn1.png" height="10" />
          &nbsp;React
        </a>
      </p>
      <p className="text-lightgray">,</p>
      <p>
        <a href="https://blazor.net" rel="nofollow">
          <img
            src="https://devblogs.microsoft.com/aspnet/wp-content/uploads/sites/16/2019/04/BrandBlazor_nohalo_1000x.png"
            height="10"
          />
          &nbsp;Blazor
        </a>
      </p>
      <p className="text-lightgray">and</p>
      <p>
        <a target="_blank" href="https://piral.io">
          <img id="piral-logo" src="https://piral.io/logo-simple.f8667084.png" height="10" />
          &nbsp;Piral
        </a>
      </p>
      <p className="text-lightgray">by</p>
      <p>
        <a target="_blank" href="https://deruwe.me">
          Dante De Ruwe
        </a>
      </p>
      <p className="text-lightgray">for</p>
      <p>
        <a target="_blank" href="https://smapiot.com">
          <img id="smapiot-logo" src="https://smapiot.com/smapiot_green.03d1162a.svg" height="20" />
        </a>
      </p>
      <p className="copyright">&mdash; © {new Date().getFullYear()}</p>
    </footer>
    <div style={{ position: 'absolute', bottom: '1rem', right: '1rem' }}>
      <PopoutButton />
    </div>
  </>
);

export default Footer;
