#include<windows.h>
#define IDC_MAIN_BUTTON 101
#define IDC_MAIN_EDIT 102
LRESULT CALLBACK proc(HWND hwnd,UINT32 message,WPARAM wp,LPARAM lp);
HWND hedit;
INT WINAPI wWinMain(HINSTANCE hInst,HINSTANCE hPrevInst,LPWSTR lpCmdLine,INT nshowCmd)
{
	//int result=MessageBox(NULL,"hahahahah","hello",MB_ICONINFORMATION|MB_YESNO);
	//注册窗体
	WNDCLASSEX wclass;//声明窗体类
	ZeroMemory(&wclass,sizeof(WNDCLASSEX));//为窗体分配内存
	wclass.cbClsExtra=NULL;
	wclass.cbSize=sizeof(WNDCLASSEX);//窗体的大小
	wclass.hbrBackground=(HBRUSH)COLOR_WINDOW;//设置窗体背景
	wclass.hCursor=LoadCursor(NULL,IDC_ARROW);//设置光标样式
	wclass.hIcon=NULL;
	wclass.hIconSm=NULL;
	wclass.hInstance=hInst;//本模块的实例句柄
	wclass.lpfnWndProc=(WNDPROC)proc;//回调函数指针
	wclass.lpszClassName="Window class";//指向注册类名的指针----------
	wclass.lpszMenuName=NULL;
	wclass.style=CS_HREDRAW|CS_VREDRAW;//设置程序的样式：当水平或垂直方向变化时重新绘制窗体
	if(!RegisterClassEx(&wclass))//注册窗体
	{
		int res=GetLastError();//捕获错误码
		MessageBox(NULL,"窗体注册失败","窗体注册错误",MB_ICONERROR);

	}
	//创建窗体
	HWND hwnd=CreateWindowEx(
		NULL,
		"Window class",//指向注册类名的指针----------
		"简单窗体",
		WS_OVERLAPPEDWINDOW,
		200,
		200,
		640,
		480,
		NULL,
		NULL,
		hInst,
		NULL
		);
	if(!hwnd)
	{
		int res=GetLastError();//捕获错误码
		MessageBox(NULL,"窗体创建失败","窗体创建错误",MB_ICONERROR);
	}
	//显示窗体
	ShowWindow(hwnd,nshowCmd);
	//创建窗体回调函数
	MSG msg;
	ZeroMemory(&msg,sizeof(MSG));
	while(GetMessage(&msg,NULL,0,0))//监听消息
	{
		TranslateMessage(&msg);//转换消息放入msg中，比如用户点击了窗口的关闭等按钮
		DispatchMessage(&msg);//调用回调函数并发送msg消息
	}

	return 0;
}
	LRESULT CALLBACK proc(HWND hwnd,UINT32 message,WPARAM wp,LPARAM lp)
	{
		switch (message)
		{
		case WM_CREATE:
			{
				hedit=CreateWindowEx(WS_EX_CLIENTEDGE,
					"EDIT",//控件类型
					"",//初始文本
					WS_CHILD|WS_VISIBLE|ES_MULTILINE|ES_AUTOHSCROLL|ES_AUTOVSCROLL,
					30,
					30,
					200,
					100,
					hwnd,
					(HMENU)IDC_MAIN_EDIT,
					GetModuleHandle(NULL),
					NULL
					);
				HGDIOBJ hf=GetStockObject(DEFAULT_GUI_FONT);//设置字体
				SendMessage(hedit,WM_SETFONT,(WPARAM)hf,MAKELPARAM(FALSE,0));
				SendMessage(hedit,WM_SETTEXT,NULL,(LPARAM)"用户在这里输入。。。");//设置文本
				//创建一个按钮
				HWND hwndbutton=CreateWindowEx(NULL,
					"BUTTON",
					"确定",
					WS_TABSTOP|WS_VISIBLE|WS_CHILD|BS_DEFPUSHBUTTON,
					50,
					150,
					100,
					24,
					hwnd,
					(HMENU)IDC_MAIN_BUTTON,
					GetModuleHandle(NULL),
					NULL
					);
				SendMessage(hedit,WM_SETFONT,(WPARAM)hf,MAKELPARAM(FALSE,0));//设置字体
			}
			break;

		case WM_COMMAND:
			switch(LOWORD(wp))
			{
			case IDC_MAIN_BUTTON:
				{
					char buffer[256];
					SendMessage(hedit,WM_GETTEXT,sizeof(buffer)/sizeof(buffer[0]),reinterpret_cast<LPARAM>(buffer));//将文本框内容赋给buffer
					MessageBox(NULL,buffer,"信息提示",MB_ICONINFORMATION);//显示buffer
				}
				break;
			}
			break;
		case WM_DESTROY:
			{
				PostQuitMessage(0);
				return 0;
			}
		default:
			break;
		}
		return DefWindowProc(hwnd,message,wp,lp);//其他消息交给由系统提供的缺省处理函数
	}