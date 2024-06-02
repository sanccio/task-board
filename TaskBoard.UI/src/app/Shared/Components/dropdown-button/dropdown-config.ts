export interface DropdownConfig<TId> {
  buttonText: string;
  menuItems: { id: TId; itemName: string }[];
}
