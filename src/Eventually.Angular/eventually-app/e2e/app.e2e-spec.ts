import { EventuallyAppPage } from './app.po';

describe('eventually-app App', () => {
  let page: EventuallyAppPage;

  beforeEach(() => {
    page = new EventuallyAppPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
