import { Card } from "./card";

export interface Column {
    id?: number;
    name: string;
    cards?: Card[];
}
