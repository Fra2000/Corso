import { iUsers } from "./i-users"

export interface iTodos {
  id: number
  todo: string
  completed: boolean
  userId: number
  author?:iUsers
}
