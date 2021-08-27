import { fireEvent, render, screen, waitFor } from "@testing-library/react";
import { BrowserRouter } from "react-router-dom";
import PetCard from "./PetCard";

import * as petService from '../../Services/PetsService';

jest.mock('../../Services/PetsService');

describe('PetCard Component', () => {
    test('Should display name', () => {
        render(
        <BrowserRouter> {/* Подаваме го защото имаме Link в компонента и ни трябва Router за линка. */}
            <PetCard name='Pesho' />
        </BrowserRouter>
        );

        expect(document.querySelector('h3').textContent).toBe('Name: Pesho');
    });

    test('Increase likes when pet button is pressed', async () => {
        petService.updateLikes.mockResolvedValue({likes: 6});

        render(
            <BrowserRouter>
                <PetCard likes={5} />
            </BrowserRouter>
        );

        fireEvent.click(screen.getByText('Pet'));

        await waitFor(() => screen.getByText('Pet'));

        expect(document.querySelector('.pet-info span').textContent).toBe('6');
    });
});