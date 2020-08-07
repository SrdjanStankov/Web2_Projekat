import { STORAGE_PASSCHG_KEY } from "../constants/storage"

export function getRequirePassChange(): boolean {
  const requirePassChange = localStorage.getItem(STORAGE_PASSCHG_KEY)
  return (requirePassChange !== 'undefined' && requirePassChange !== 'false' && !!requirePassChange);
}
