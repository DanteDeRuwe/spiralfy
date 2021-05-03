import { createBlazorApi } from 'piral-blazor';
import { createInstance, Piral, SetErrors, SetLayout } from 'piral-core';
import { createMenuApi } from 'piral-menu';
import * as React from 'react';
import { render } from 'react-dom';
import { errors, layout } from './layout';

// change to your feed URL here (either using feed.piral.cloud or your own service)
const feedUrl = 'https://feed.piral.cloud/api/v1/pilet/spiralfy';

const instance = createInstance({
  plugins: [createBlazorApi(), createMenuApi()],
  requestPilets() {
    return fetch(feedUrl)
      .then(res => res.json())
      .then(res => res.items);
  },
});

const piral = (
  <Piral instance={instance}>
    <SetLayout layout={layout} />
    <SetErrors errors={errors} />
  </Piral>
);

render(piral, document.querySelector('#app'));
