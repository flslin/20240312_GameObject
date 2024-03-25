using SDL2;

// 파일이름이 같으면 리소스 재사용

class ResourceManager
{
    protected static Dictionary<string, IntPtr> Databases = new Dictionary<string, IntPtr>();

    public static IntPtr Load(string _fileName, SDL.SDL_Color _colorKey)
    {
        if (!Databases.ContainsKey(_fileName))
        {
            string dir = Directory.GetParent(System.Environment.CurrentDirectory).Parent.Parent.FullName;

            unsafe
            {
                SDL.SDL_Surface* mySurface = (SDL.SDL_Surface*)SDL.SDL_LoadBMP(dir + "/data/" + _fileName); // 정사각형으로 정확히 맞출 필요 없음
                SDL.SDL_SetColorKey((IntPtr)mySurface, 1, SDL.SDL_MapRGBA(mySurface->format, _colorKey.r, _colorKey.g, _colorKey.b, _colorKey.a)); // 키값을 빼고 텍스쳐 만들어달라 요청
                IntPtr myTexture = SDL.SDL_CreateTextureFromSurface(Engine.GetInstance().myRenderer, (nint)mySurface); // 필요함

                Databases[_fileName] = myTexture;

                SDL.SDL_FreeSurface((nint)mySurface); // 썼으면 지워줌 C++코드라 자동으로 안풀어줌
            }
        }
        return Databases[_fileName];
    }

    public static IntPtr Find(string _fileName)
    {
        return Databases[_fileName];
    }
}

