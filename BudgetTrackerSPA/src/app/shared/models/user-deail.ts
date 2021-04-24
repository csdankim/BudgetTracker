import { Income } from './income';
import { Expenditure } from './expenditure';

export interface UserDetail {
  id: number;
  email: string;
  fullname: string;
  joinedOn: Date;
  incomes: Income[];
  expenditures: Expenditure[];
}