import * as React from 'react';

const About: React.FC = () => (
  <div className="container">
    <div className="row">
      <div className="col mb-5 d-flex justify-content-center">
        <img src="https://i.imgur.com/DpDlQP9.jpg" height="500" />
      </div>
      <div className="col">
        <h1 className="h1">Welcome to Spiralfy 🎉</h1>
        <p>Spiralfy is a way to switch up your Spotify experience!</p>
        <p>
          Spiralfy picks one playlist at random, shuffle playing its songs, and whenever you feel like you want a
          different vibe, you let Spiralfy pick a new playlist to listen to.
        </p>
        <p>
          Unfortunately, you will need a <b>Spotify Premium account</b> to use Spiralfy. If you have one, great! Log in
          using the button in the header!
        </p>
        <p>
          If you want to know more about Spiralfy, you can read&nbsp;
          <a
            className="link"
            href="https://dev.to/dantederuwe/switching-up-your-spotify-experience-with-microfrontends-and-blazor-4k72"
          >
            this article!
          </a>
        </p>
      </div>
    </div>
  </div>
);

export default About;
