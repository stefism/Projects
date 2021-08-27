import * as petsService from './PetsService';

import { rest } from 'msw';
import { setupServer } from 'msw/node';

const fakeServer = setupServer(
    rest.get('http://localhost:5000/pets', (request, response, context) => {
        return response(context.json([{likes: 10}]));
    })
);

beforeAll(() => fakeServer.listen());

afterEach(() => fakeServer.resetHandlers());

afterAll(() => fakeServer.close());

describe('Pet service', () => {
    test('Verify whether the likes is number', (done) => {
        petsService.getAll()
        .then(result => {
            expect(typeof(result[0].likes)).toBe('number');
            done(); // Когато се прави асинхронна заявка, задължително се ползва done с което му се казва да изчака then да се изпълни.
        });
    });
});