﻿
#include "pch.h"
#include <iostream>
#include <algorithm>
using namespace std;
int b[260][260], n;
char s[260][260], a[260][260];

int main()
{
	freopen("in.txt", "r", stdin);
	int i, j, sum = 0, sum1 = 0, k = 0, x, y;
	cin >> n;
	for (i = 1; i <= n; i++)
		for (j = 1; j <= n; j++)
			s[i][j] = '-';

	s[n][n] = '#';

	for (i = 1; i <= n; i++)
		cin >> a[i] + 1;

	for (i = 1; i <= n; i++)
	{
		sum += (int)(a[1][i] - '0');
		b[1][i] = sum;
		sum1 += (int)(a[i][1] - '0');
		b[i][1] = sum1;
	}

	for (i = 2; i <= n; i++)
		for (j = 2; j <= n; j++)
			b[i][j] = min(b[i][j - 1], b[i - 1][j]) + (int)(a[i][j] - '0');
	x = n;
	y = n;
	while (x != 0 && y != 0)
	{
		if (b[x][y - 1] <= b[x - 1][y] && x > 1 && y > 1)
		{
			s[x][y - 1] = '#';
			y--;
		}
		else if (b[x - 1][y] < b[x][y - 1] && x > 1 && y > 1)
		{
			s[x - 1][y] = '#';
			x--;
		}
		else if (x == 1)
		{
			s[x][y - 1] = '#';
			y--;
		}
		else if (y == 1)
		{
			s[x - 1][y] = '#';
			x--;
		}
		if (x == 0 && y == 0)
			break;
	}
	for (i = 1; i <= n; i++)
	{
		for (j = 1; j <= n; j++)
			cout << s[i][j];
		cout << endl;
	}
	return 0;
}

