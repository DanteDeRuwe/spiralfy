import * as React from 'react';
import { useLocation } from 'react-router-dom';
import SpotifyPlayer from 'react-spotify-web-playback';
const queryString = require('query-string');

const Player: React.FC = () => {
  const { hash } = useLocation();
  const { access_token } = queryString.parse(hash);

  if (!access_token) return;

  return (
    <div style={{ display: 'none' }}>
      <SpotifyPlayer
        name="Spiralfy"
        token={access_token}
        uris={['spotify:track:2bNCdW4rLnCTzgqUXTTDO1']} //this track is 4'33 by John Cage: 4 minutes and 33 seconds of silence
        autoPlay={true}
      />
    </div>
  );
};

export default Player;
