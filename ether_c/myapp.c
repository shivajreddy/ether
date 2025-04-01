#include <windows.h>

#define ID_BUTTON 1
#define ID_EDIT   2

LRESULT CALLBACK WindowProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam) {
    static HWND hEdit, hButton;
    
    switch (uMsg) {
        case WM_CREATE:
            // Create an input field
            hEdit = CreateWindow("EDIT", "",
                WS_CHILD | WS_VISIBLE | WS_BORDER | ES_AUTOHSCROLL,
                20, 20, 200, 25, hwnd, (HMENU)ID_EDIT, NULL, NULL);
            
            // Create a button
            hButton = CreateWindow("BUTTON", "Click Me",
                WS_CHILD | WS_VISIBLE,
                20, 60, 100, 30, hwnd, (HMENU)ID_BUTTON, NULL, NULL);
            break;

        case WM_COMMAND:
            if (LOWORD(wParam) == ID_BUTTON) {
                char text[100];
                GetWindowText(hEdit, text, sizeof(text));
                MessageBox(hwnd, text, "You Entered:", MB_OK);
            }
            break;

        case WM_DESTROY:
            PostQuitMessage(0);
            return 0;
    }
    return DefWindowProc(hwnd, uMsg, wParam, lParam);
}

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow) {
    WNDCLASS wc = {0};
    wc.lpfnWndProc = WindowProc;
    wc.hInstance = hInstance;
    wc.lpszClassName = "MyAppClass";

    RegisterClass(&wc);

    HWND hwnd = CreateWindow("MyAppClass", "My C Windows App",
        WS_OVERLAPPEDWINDOW | WS_VISIBLE,
        CW_USEDEFAULT, CW_USEDEFAULT, 400, 200,
        NULL, NULL, hInstance, NULL);

    MSG msg;
    while (GetMessage(&msg, NULL, 0, 0)) {
        TranslateMessage(&msg);
        DispatchMessage(&msg);
    }
    return 0;
}



