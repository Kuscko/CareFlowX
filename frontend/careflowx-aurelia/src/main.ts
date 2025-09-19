import Aurelia from 'aurelia';
import { RouterConfiguration } from '@aurelia/router';
import { MyApp } from './my-app';

Aurelia
  // Configure the router to use hash-based routing instead of pushState
  // Because we are serving the app as static files without a backend that supports pushState
  .register(RouterConfiguration.customize({ useUrlFragmentHash: true }))
  .app(MyApp)
  .start();
