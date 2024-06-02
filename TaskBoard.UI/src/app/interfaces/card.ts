import { Priority } from "./priority";

export interface Card {
    id?: number;
    title: string;
    columnId: number;
    description: string;
    dueDate?: Date;
    priorityId?: number;
    priority?: Priority;
}
