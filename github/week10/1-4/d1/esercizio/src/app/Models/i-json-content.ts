import { iPost } from "./ipost"

export interface IJsonContent {
  posts: iPost[]
  total: number
  skip: number
  limit: number
}
