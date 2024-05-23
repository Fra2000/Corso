import { Posts } from "./posts"

export interface Jsonc {
  posts: Posts[]
  total: number
  skip: number
  limit: number
}
