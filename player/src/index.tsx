import * as React from 'react';
import { PiletApi } from 'spiralfy-appshell';
import Player from './Player';

export function setup(app: PiletApi) {
  app.registerExtension('header-items', Player);
}
