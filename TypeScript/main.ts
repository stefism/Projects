let a: number;
let b: boolean;
let c: string;
let d: any;
let e: number[] = [1, 2, 3];
let f: any[] = [1, true, 'a', false];

import { Point } from './Class'

enum Color {Red = 0, Green = 1, Blue = 2};

let backgroundColor = Color.Blue;

let message = 'Test message';
let endsWith = message.endsWith('c'); //boolean

let message2; //If not declare type, we dont able to use intellisence.
// To fix this:
let alternativeWay = (<string>message2).endsWith('e');
let or = (message2 as string).endsWith('c');

let point = new Point(3, 5);
let x = point.x;
point.x = 10;
point.draw();