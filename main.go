package main

import (
	"syscall"
	"unsafe"

	// "golang.org/x/sys/windows"
	"github.com/lxn/win"
)

var (
	className = syscall.StringToUTF16Ptr("MyGoAppClass")
	windowName = syscall.StringToUTF16Ptr("My Go Windows App")
)

func wndProc(hwnd win.HWND, msg uint32, wParam, lParam uintptr) uintptr {
	switch msg {
	case win.WM_DESTROY:
		win.PostQuitMessage(0)
		return 0
	}
	return win.DefWindowProc(hwnd, msg, wParam, lParam)
}

func main() {
	hInstance := win.GetModuleHandle(nil)

	// Register Window Class
	var wc win.WNDCLASSEX
	wc.CbSize = uint32(unsafe.Sizeof(wc))
	wc.LpfnWndProc = syscall.NewCallback(wndProc)
	wc.HInstance = hInstance
	wc.LpszClassName = className

	if win.RegisterClassEx(&wc) == 0 {
		panic("Failed to register window class")
	}

	// Create Window
	hwnd := win.CreateWindowEx(
		0, className, windowName,
		win.WS_OVERLAPPEDWINDOW|win.WS_VISIBLE,
		win.CW_USEDEFAULT, win.CW_USEDEFAULT, 500, 300,
		0, 0, hInstance, nil,
	)

	if hwnd == 0 {
		panic("Failed to create window")
	}

	// Message Loop
	var msg win.MSG
	for win.GetMessage(&msg, 0, 0, 0) > 0 {
		win.TranslateMessage(&msg)
		win.DispatchMessage(&msg)
	}
}

