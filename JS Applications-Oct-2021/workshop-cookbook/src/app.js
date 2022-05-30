import { page } from './lib.js';
import decorateContext from './middlewares/render.js';
import { homePage } from './views/home.js';

page(decorateContext);
page('/', homePage);

page.start();